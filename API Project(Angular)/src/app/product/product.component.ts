import { Component, OnInit, Input } from '@angular/core';

import { Product } from '../product.model';
import { CartItem } from "../cart.model";
import { ProductService } from "../products.service";
import { CartService } from '../cart.service'


@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  @Input() product!: Product;
  show: boolean = false;
  newItem!: CartItem;
  cartItems: CartItem[] = [];
  quantity: number = 1;

  constructor(private productService: ProductService, private cartService: CartService) { }

  ngOnInit(): void {
  }

  onDeleteProduct()
  {
    this.productService.deleteProduct(this.product.productId).subscribe( response =>
      {
      console.log(response)
      window.location.reload();
      });

  }

  onAddToCart()
  {
    this.newItem =
    {
      itemId: 0,
      itemQuantity: 1,
      itemTotalCost: this.product.productPrice,
      productId: this.product.productId,
      product:
      {
        productId: this.product.productId,
        productTitle: this.product.productTitle,
        productPrice: this.product.productPrice
      }
    };
    this.cartService.fetchItems().subscribe(cartitems=>
      {
        this.cartItems = cartitems;
        this.cartItems.forEach(element => {
          if (element.product.productTitle === this.newItem.product.productTitle) {
            this.quantity++;
            this.newItem.itemQuantity = this.quantity;
            this.newItem.itemTotalCost = this.newItem.itemQuantity * this.product.productPrice;
            this.cartService.deleteItem(element.itemId).subscribe(response=>{console.log(response);
            })
          }
        });
            this.cartService.addItem(this.newItem).subscribe(response=>{console.log(response);
            });
        });
  }

}
