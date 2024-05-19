namespace BackendBootcamp.Homework.Week2.Core.DTOs.BookDTOs
{
    public record BookCreateRequestDTO(string Title, string Author, string PublicationDate, decimal Price);
}
