import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

import { Product } from './product.model';
import { Category } from './category.model';

@Injectable()

export class ProductService
{
    constructor(private http: HttpClient)
    {
    }

  fetchProducts ()
  {
    return this.http.get<Product[]>("http://localhost:5034/Product")
    .pipe(
      map(products =>
        {
          const productlist: Product[] = [];
          for(const prod in products)
            {
              console.log(products[prod]);

              productlist.push({...products[prod]});
            }


          return productlist;
      }))
  }

  fetchProduct(id: Number)
  {
    return this.http.get<Product>("http://localhost:5034/Product/" + id)
    .pipe(
      map(product =>
        {
        let productItem!: Product;
        productItem = product;
        return productItem;
        }
      )
    )
  }

  addProduct(newProduct: {productTitle: string, productPrice: number,
     productDescription: string, productCategoryId: number, productImage: string})
     {
       return this.http.post("http://localhost:5034/Product", newProduct)
     }

  updateProduct(id: number, updatedProduct: { productTitle: string, productPrice: number,
     productDescription: string, productCategoryId: number, productImage: string })
     {
       return this.http.put("http://localhost:5034/Product/" + id, updatedProduct)
     }

  deleteProduct(id: number)
    {
      return this.http.delete("http://localhost:5034/Product/" + id)
    }

  fetchCategories()
    {
      return this.http.get<Category[]>("http://localhost:5034/Category").pipe(
        map(categories =>
          {
            const categorylist: Category[] = [];
            for(const cat in categories)
              {
                categorylist.push({...categories[cat]});
              }
              return categorylist;
          }));
      }
    }
