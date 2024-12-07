import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { CartService } from '../cart.service';
import { ProductService } from '../products.service';
import { CartItem } from '../cart.model';
import { Product } from '../product.model'

@Component({
  selector: 'app-product-cart',
  templateUrl: './product-cart.component.html',
  styleUrls: ['./product-cart.component.css']
})
export class ProductCartComponent implements OnInit {
  loadedItems: CartItem[] = [];
  loadedProduct!: Product;
  constructor(private http: HttpClient, private cartService: CartService, private productService: ProductService) { }

  ngOnInit(): void {
    this.cartService.fetchItems().subscribe(cartitems=>
      {
        this.loadedItems = cartitems;
      })

  }

  onRemoveItem(id: number)
  {
    this.cartService.deleteItem(id).subscribe( response =>
      {
        console.log(response);
        window.location.reload();
      })
  }

}
