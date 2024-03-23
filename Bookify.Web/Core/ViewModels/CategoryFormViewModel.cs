namespace Bookify.Web.Core.ViewModels
{
    public class CategoryFormViewModel
    {
        public int Id { get; set; }
        [MaxLength(100, ErrorMessage ="Max length must not be more than 100 char.")]
        public string Name { get; set; } = null!;
    }
}
