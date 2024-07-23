namespace DotNet8WebApi.SpecificationPattern.Mapper;

public static class ChangeModel
{
    public static Tbl_Blog Map(this BlogRequestModel requestModel) =>
        new Tbl_Blog
        {
            BlogTitle = requestModel.BlogTitle,
            BlogAuthor = requestModel.BlogAuthor,
            BlogContent = requestModel.BlogContent
        };
}
