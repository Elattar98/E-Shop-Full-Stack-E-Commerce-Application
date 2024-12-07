import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from "@angular/common/http";
import { Routes, RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductComponent } from './product/product.component';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductService } from './products.service';
import { CartService } from './cart.service';
import { ShortenPipe } from './shorten.pipe';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ProductAdditionComponent } from './product-addition/product-addition.component';
import { ProductEditComponent } from './product-edit/product-edit.component';
import { ProductCartComponent } from './product-cart/product-cart.component';
import { NavComponent } from './nav/nav.component';

const appRoutes: Routes = [
  {path: '', component: ProductListComponent},
  {path: 'details/:id', component: ProductDetailsComponent},
  {path: 'addproduct', component: ProductAdditionComponent},
  {path: 'editproduct/:id', component: ProductEditComponent},
  {path: 'cart', component: ProductCartComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    ProductComponent,
    ProductListComponent,
    ShortenPipe,
    ProductDetailsComponent,
    ProductAdditionComponent,
    ProductEditComponent,
    ProductCartComponent,
    NavComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    ReactiveFormsModule
  ],
  providers: [ProductService, CartService],
  bootstrap: [AppComponent]
})
export class AppModule { }
