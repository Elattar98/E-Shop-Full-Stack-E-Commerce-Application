import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

import { Product } from '../product.model';
import { Category } from '../category.model'
import { ProductService } from '../products.service';


@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  loadedProducts: Product[] = [];
  loadedCategories: Category[] = [];
  showAll: boolean = true;
  // products: any= [];
  constructor(private http: HttpClient, private productService: ProductService) {

  }

  ngOnInit(): void {
    this.productService.fetchProducts().subscribe( products =>
          {
            this.loadedProducts = products;
          }
        );
    this.productService.fetchCategories().subscribe( categories =>
      {
          this.loadedCategories = categories;
          // this.catProducts = this.loadedCategories.products;
          console.log(this.loadedCategories);

      });
  }

  onAll()
    {
      this.showAll = true;
      this.productService.fetchProducts().subscribe( products =>
            {
              this.loadedProducts = products;
            }
          );
    }

  onCategory(catId: number)
    {
      this.showAll = false;
      this.productService.fetchCategories().subscribe( categories =>
        {
            this.loadedCategories = categories;
            this.loadedProducts = this.loadedCategories[catId-1].products;
            // this.catProducts = this.loadedCategories.products;
        });
    }
}
