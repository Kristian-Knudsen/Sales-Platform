import { Product } from "@/types";

export const getStoreProducts = () : Promise<Product[]> => {
    return new Promise( async (resolve, reject) => {
        try {
            const request = await fetch("https://localhost:32001/api/products");
            const data = await request.json();

            resolve(data);
        } catch(e) {
            reject(e);
        }
    })
}