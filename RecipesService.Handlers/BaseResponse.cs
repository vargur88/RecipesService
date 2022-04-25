namespace RecipesService.Handlers
{
    public class BaseResponse
    {
        public string Error { get; set; }

        public bool HasError() => string.IsNullOrEmpty(Error) == false;
    }
}
