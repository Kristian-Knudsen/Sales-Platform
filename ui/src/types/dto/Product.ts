import { Product } from "..";

export type CreateProductDTO = Omit<Product, "store" | "id" | "createdAt" | "updatedAt">