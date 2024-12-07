import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';

import { ProductService } from "../products.service";
import { Product } from "../product.model";

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  product!: Product;
  productID!: Number;

  constructor(private route: ActivatedRoute, private productService: ProductService) { }

  ngOnInit(): void
  {

    this.route.params.subscribe(
      (params: Params)=> {
        this.productID = params['id'];
      }
    );

    this.productService.fetchProduct(this.productID).subscribe(product=>
      {
        this.product = product;
      });
  }

}
