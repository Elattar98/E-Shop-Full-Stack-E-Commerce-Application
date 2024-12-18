import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

import { Product } from './product.model';
import { CartItem } from './cart.model'

@Injectable()

export class CartService
{
  constructor(private http: HttpClient)
  {
  }

  fetchItems ()
  {
    return this.http.get<CartItem[]>("http://localhost:5034/Cart")
    .pipe(
      map(items =>
        {
          const cartlist: CartItem[] = [];
          for(const item in items)
            {
              cartlist.push({...items[item]});
            }

          return cartlist;
      }))
  }

  addItem(newItem: CartItem)
     {
       return this.http.post("http://localhost:5034/Cart", newItem)
     }

  updateItem(id: number, updatedItem: CartItem)
    {
      return this.http.put("http://localhost:5034/Cart"+id, updatedItem)
    }

  deleteItem(id: number)
    {
      return this.http.delete("http://localhost:5034/Cart/" + id)
    }
}
