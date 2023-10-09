using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithFilersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFilersForCountSpecification(ProductSpecParams productPrams)
        :base(x =>
            (string.IsNullOrEmpty(productPrams.Search) || x.Name.ToLower().Contains(productPrams.Search)) &&
            (!productPrams.BrandId.HasValue || x.ProductBrandId == productPrams.BrandId) &&
            (!productPrams.TypeId.HasValue || x.ProductTypeId == productPrams.TypeId)
        )
        {
            
        }
    }
}