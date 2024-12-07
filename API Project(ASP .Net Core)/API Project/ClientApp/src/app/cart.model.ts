export interface CartItem
{
  itemId: number;
  itemQuantity: number;
  itemTotalCost: number;
  productId: number;
  product:
  {
    productId: number,
    productTitle: string,
    productPrice: number
  }
}
