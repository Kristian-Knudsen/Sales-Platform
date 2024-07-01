import { CreateProductDTO } from "@/types/dto/Product";
import { GET, POST, ResponseMessage, DELETE } from "./Base";
import { Product } from '@/types';

export const createProduct = async (data: CreateProductDTO) : Promise<ResponseMessage<string>> => {
    try {
        return await POST<CreateProductDTO, string>('products', data);
    } catch (error) {
        throw error;
    }
};

export const getProductsFromStore = async (store: string) : Promise<ResponseMessage<Product[]>>  => {
    try {
        return await GET<Product[]>(`stores/${store}/products`);
    } catch (error) {
        throw error;
    }
};

export const deleteProduct = async (id: string) : Promise<ResponseMessage<string>> => {
    try {
        return await DELETE<string>(`products/${id}`);
    } catch (error) {
        throw error;
    }
};