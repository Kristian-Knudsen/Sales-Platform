import { defineStore } from "pinia";
import { OrderSimple } from '@/types';
import { GET } from "@/services/Base";
import { useToast } from '@/components/ui/toast/use-toast';
import { ref, type Ref } from 'vue';
const { toast } = useToast();

export const useOrderStore = defineStore('orders', () => {
    const simpleOrderData: Ref<OrderSimple[]> = ref([]);
    const isInitialized: Ref<boolean> = ref(false);
    const selectedOrder: Ref<string> = ref("");

    const initialize = async(): Promise<void> => {
        if(simpleOrderData.value.length === 0 || isInitialized.value === false) {
            await getOrdersSimple();
        }

        isInitialized.value = true;
    };

    const getOrdersSimple = async(): Promise<void> => {
        try {
            const storeId = localStorage.getItem('store');
            const jwt = localStorage.getItem('jwt') || '';

            let response = await GET<OrderSimple[]>(`stores/${storeId}/orders`, jwt);
            if(response.success) {
                simpleOrderData.value = response.message;
            }
            
        } catch (error) {
            toast({
                title: 'Yikes - Nasty error happend while fetching getOrdersSimple!',
                description: JSON.stringify(error)
            });
        }
    };

    initialize();

    return { simpleOrderData, selectedOrder, getOrdersSimple }
});