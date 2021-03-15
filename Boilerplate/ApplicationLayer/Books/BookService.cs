using AutoMapper;
using Boilerplate.DomainLayer.Authors;
using Boilerplate.DomainLayer.Books;
using Boilerplate.Helpers.Pagination;
using Boilerplate.Helpers.Repository;
using Boilerplate.Helpers.Sorting;
using Boilerplate.Models.Books;
using Boilerplate.Models.Pagination;
using Boilerplate.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate.ApplicationLayer.Books
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Book, Guid> _bookRepository;
        private readonly IRepository<Author, Guid> _authorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IRepository<Book, Guid> bookRepository, IRepository<Author, Guid> authorRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BookPaginationDto> Find(int pageSize, int currentPage, Sort sort, string column, string authorId)
        {
            try
            {
                IEnumerable<Book> books = await _bookRepository.FindAsync();

                // filter
                if (authorId != null)
                    books = books.Where(x => x.AuthorId == Guid.Parse(authorId));

                // sort
                if (column != null)
                {
                    if (typeof(Book).GetProperty(column) != null)
                    {
                        string[] joinColumns = { "author_name" };
                        if (joinColumns.Contains(column))
                        {
                            if (column.Equals("author_name"))
                            {
                                Func<Book, string> AuthorNameSelector() => x => x?.Author?.Name;
                                books = DynamicSorting.SortJoinColumn<Book, string>(books, sort, AuthorNameSelector());
                            }
                        }
                        else
                        {
                            books = DynamicSorting.SortColumn<Book>(books, sort, typeof(Book).GetProperty(column));
                        }
                    }
                    else
                    {
                        throw ErrorResponse.BadRequest();
                    }
                }
                else
                {
                    books = DynamicSorting.SortColumn(books, sort, typeof(Book).GetProperty("Id"));
                }

                // pagination
                int booksCount = books.Count();
                books = Pagination.Paging<Book>(books, currentPage, pageSize);

                return new BookPaginationDto
                {
                    Total = booksCount,
                    Books = _mapper.Map<IEnumerable<Book>, IEnumerable<BookDto>>(books),
                };
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                throw ErrorResponse.InternalServerError(ex);
            }
        }
        public async Task<BookDto> Add(CreateBookDto createBook)
        {
            try
            {
                await _authorRepository.FindByIdAsync(createBook.AuthorId);
                Book book = Book.Create(createBook);

                await _bookRepository.AddAsync(book);
                await _unitOfWork.CommitAsync();

                return _mapper.Map<Book, BookDto>(book);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                throw ErrorResponse.InternalServerError(ex);
            }
        }

        public async Task<BookDto> Update(Guid id, CreateBookDto updatedBook)
        {
            try
            {
                Book book = _mapper.Map<CreateBookDto, Book>(updatedBook);

                _bookRepository.UpdateAsync(id, book);
                await _unitOfWork.CommitAsync();

                return _mapper.Map<Book, BookDto>(book);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                throw ErrorResponse.InternalServerError(ex);
            }
        }
        public async Task<BookDto> Remove(Guid id)
        {
            try
            {
                Book book = _bookRepository.Remove(id);
                await _unitOfWork.CommitAsync();

                return _mapper.Map<Book, BookDto>(book);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                throw ErrorResponse.InternalServerError(ex);
            }
        }
    }
}
