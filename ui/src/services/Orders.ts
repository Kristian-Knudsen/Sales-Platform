import { GET, ResponseMessage } from "./Base";

export const deleteProduct = async (id: string) : Promise<ResponseMessage<string>> => {
    try {
        return await GET<string>(`products/${id}`);
    } catch (error) {
        throw error;
    }
};