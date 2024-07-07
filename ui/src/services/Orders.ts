import { Order, OrderExtended } from "@/types";
import { GET, ResponseMessage } from "./Base";

export const getOrders = async (storeId: string) : Promise<ResponseMessage<Order[]>> => {
    try {
        return await GET<Order[]>(`orders/${storeId}`);
    } catch (error) {
        throw error;
    }
};

export const getSpecificOrder = async (storeId: string, orderId: string): Promise<ResponseMessage<OrderExtended>> => {
    try {
        const jwt = localStorage.getItem('jwt') || '';
        return await GET<OrderExtended>(`stores/${storeId}/order/${orderId}`, jwt);
    } catch (error) {
        throw error;
    }
}
