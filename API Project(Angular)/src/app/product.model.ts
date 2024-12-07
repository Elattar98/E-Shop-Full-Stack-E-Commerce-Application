export interface Product{
  productId: number;
  productTitle: string;
  productPrice: number;
  productDescription: string;
  productCategoryId: number;
  productCategory: string;
  productImage: string;
  productRating: {
  rate: number,
  count: number
};

}
