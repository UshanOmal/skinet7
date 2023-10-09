using Core.Entities;
using Core.Specifications;

namespace Core
{
    public class ProductWithTypesAndBrandsSpecification:BaseSpecification<Product>
    {
        public ProductWithTypesAndBrandsSpecification(ProductSpecParams productPrams)
        :base(x =>
            (string.IsNullOrEmpty(productPrams.Search) || x.Name.ToLower().Contains(productPrams.Search)) &&
            (!productPrams.BrandId.HasValue || x.ProductBrandId == productPrams.BrandId) &&
            (!productPrams.TypeId.HasValue || x.ProductTypeId == productPrams.TypeId)
        )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AdddOrderBy(x => x.Name);
            ApplyPaging(productPrams.PageSize * (productPrams.PageIndex - 1),productPrams.PageSize);

            if(!string.IsNullOrEmpty(productPrams.Sort))
            {
                switch(productPrams.Sort)
                {
                    case "priceAsc":
                        AdddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AdddOrderByDesending(p => p.Price);
                        break;
                    default:
                        AdddOrderBy(n => n.Name);
                        break;
                }
            }
        }

        public ProductWithTypesAndBrandsSpecification(int id):base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}