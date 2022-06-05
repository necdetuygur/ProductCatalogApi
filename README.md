git push origin --all && git push gitlab --all && exit

# ProductCatalogApi
# LC Waikiki .Net BootCamp Bitirme Projesi Ödevi

Bir internet sitesindeki ürün ve kategoriyi örnek alarak bir web api oluşturdum.

## Paketler 
    dotnet add package Microsoft.EntityFrameworkCore -v 5.0.10
    dotnet add package AutoMapper -v 11.0.0
    dotnet add package FluentValidation -v 10.0.4
    dotnet add package FluentValidation.DependencyInjectionExtensions -v 9.5.4
    dotnet add package Microsoft.EntityFrameworkCore.Design -v 5.0.10
    dotnet add package Microsoft.EntityFrameworkCore.Tools -v 5.0.10
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer -v 5.0.10
    
    
    
# Endpoints
## Brands
|HTTP|URL|METOT|
|---|---|---|
|GET| https://localhost:7170/api/Brands |GetBrands|
|GET| https://localhost:7170/api/Brands/{id} |GetById|

    
# Endpoints
## Categories
|HTTP|URL|METOT|
|---|---|---|
|GET| https://localhost:7170/api/Categories |GetCategories|
|GET| https://localhost:7170/api/Categories/{id} |GetById|


# Endpoints
## Colors
|HTTP|URL|METOT|
|---|---|---|
|GET| https://localhost:7170/api/Colors |GetColors|
|GET| https://localhost:7170/api/Colors/{id} |GetById|


# Endpoints
## Users
|HTTP|URL|METOT|
|---|---|---|
|GET| https://localhost:7170/api/Users |GetUsers|
|GET| https://localhost:7170/api/Users/{id} |GetById|
|POST| https://localhost:7170/api/Users |CreateUser|
|POST| https://localhost:7170/api/Users/Login |Login|

# Endpoints
## UseCases
|HTTP|URL|METOT|
|---|---|---|
|GET| https://localhost:7170/api/UseCases |GetUseCases|
|GET| https://localhost:7170/api/UseCases/{id} |GetById|


# Endpoints
## Products
|HTTP|URL|METOT|
|---|---|---|
|GET| https://localhost:7170/api/Products |GetProducts|
|GET| https://localhost:7170/api/Products/{id} |GetById|
|POST| https://localhost:7170/api/Products |CreateProduct|
|PUT| https://localhost:7170/api/Products |UpdateProduct|
|POST| https://localhost:7170/api/Products/PictureUpload |PictureUpload|


# Endpoints
## Orders
|HTTP|URL|METOT|
|---|---|---|
|GET| https://localhost:7170/api/Orders |GetOrders|
|GET| https://localhost:7170/api/Orders/{id} |GetById|
|POST| https://localhost:7170/api/Orders |CreateOrder|
|PUT| https://localhost:7170/api/Orders |UpdateOrder|
|DELETE| https://localhost:7170/api/Orders/{id} |DeleteOrder|
|GET| https://localhost:7170/api/Orders/GetByUserIdOrder |GetByUserIdOrder|
|GET| https://localhost:7170/api/Orders/GetByProductIdOrder |GetByProductIdOrder|


# API 

## GetCategories
![GetCategoriesPicture](/images/category_getall.png)



## Entities
## Product
![entity1](images/product.png)
## Category
![entity2](images/category.png)
