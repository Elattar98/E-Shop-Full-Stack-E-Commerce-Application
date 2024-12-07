import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from "@angular/forms";
import { ActivatedRoute, Params, Router } from '@angular/router';

import { ProductService } from "../products.service";
import { Product } from "../product.model";
import { Category } from "../category.model";

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {
  loadedProduct!: Product;
  updatedProduct!: { productTitle: string, productPrice: number,
     productDescription: string, productCategoryId: number, productImage: string };
  productID!: number;
  categories!: Category[];
  editProductForm!: FormGroup;
  isFormReady: boolean = false;

  constructor(private productService: ProductService, private route: ActivatedRoute, private router: Router)
  {
    this.editProductForm = new FormGroup({
      'Title': new FormControl(null, Validators.required),
      'Price': new FormControl(null, Validators.required),
      'Description': new FormControl(null, Validators.required),
      'Category': new FormControl(null, Validators.required),
      'Image': new FormControl(null, Validators.required)
    });

  }

  ngOnInit(): void {
    this.route.params.subscribe(
      (params: Params)=> {
        this.productID = params['id'];
      }
    );

    this.productService.fetchCategories().subscribe(categories=>
      {
        this.categories = categories;
      });

    this.productService.fetchProduct(this.productID).subscribe( product =>
      {
        this.isFormReady = true;
        this.loadedProduct = product;
        this.editProductForm = new FormGroup({
          'Title': new FormControl(this.loadedProduct.productTitle),
          'Price': new FormControl(this.loadedProduct.productPrice),
          'Description': new FormControl(this.loadedProduct.productDescription),
          'Category': new FormControl(this.loadedProduct.productCategoryId),
          'Image': new FormControl(this.loadedProduct.productImage)
        });

      });




  }

  onSubmit()
  {
    console.log(this.editProductForm);

    this.updatedProduct=
    {
      productTitle: this.editProductForm.value.Title,
      productPrice: this.editProductForm.value.Price,
      productDescription: this.editProductForm.value.Description,
      productCategoryId: this.editProductForm.value.Category,
      productImage: this.editProductForm.value.Image,
    }

    this.productService.updateProduct(this.productID, this.updatedProduct).subscribe(response =>
      {
        console.log(response);
        this.router.navigate(['/'])
      });
      console.log(this.editProductForm);

  }

}
