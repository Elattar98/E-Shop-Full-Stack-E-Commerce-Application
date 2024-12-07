import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from "@angular/forms";

import { ProductService } from "../products.service";
import { Category } from "../category.model";

@Component({
  selector: 'app-product-addition',
  templateUrl: './product-addition.component.html',
  styleUrls: ['./product-addition.component.css']
})
export class ProductAdditionComponent implements OnInit {
  addProductForm!: FormGroup;
  newProduct!: {productTitle: string, productPrice: number,
     productDescription: string, productCategoryId: number, productImage: string};
  categories!: Category[];

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.addProductForm = new FormGroup({
      'Title': new FormControl(null, Validators.required),
      'Price': new FormControl(null, Validators.required),
      'Description': new FormControl(null, Validators.required),
      'Category': new FormControl(null, Validators.required),
      'Image': new FormControl(null, Validators.required)
    })
    this.productService.fetchCategories().subscribe(categories=>
      {
        this.categories = categories;
      });
  }

  onSubmit()
  {
    this.newProduct = {
      productTitle: this.addProductForm.value.Title,
      productPrice: this.addProductForm.value.Price,
      productDescription: this.addProductForm.value.Description,
      productCategoryId: this.addProductForm.value.Category,
      productImage: this.addProductForm.value.Image
    };

    this.productService.addProduct(this.newProduct).subscribe(response=>{
      console.log(response);

    });
  }

}
