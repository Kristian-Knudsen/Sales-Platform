import { defineStore } from "pinia";
import { Product } from '@/types';
import { GET } from "@/services/Base";
import { useToast } from '@/components/ui/toast/use-toast';
import { ref, type Ref } from 'vue';
const { toast } = useToast();

export const useProductStore = defineStore('products', () => {
    const productData: Ref<Product[]> = ref([]);
    const isInitialized: Ref<boolean> = ref(false);

    const initialize = async(): Promise<void> => {
        if(productData.value.length === 0 || isInitialized.value === false) {
            await getProductsFromStore();
        }

        isInitialized.value = true;
    };

    const getProductsFromStore = async(): Promise<void> => {
        try {
            const storeId = localStorage.getItem('store');

            let response = await GET<Product[]>(`stores/${storeId}/products`);

            if(response.success) {
                productData.value = response.message;
            }
            
        } catch (error) {
            toast({
                title: 'Yikes - Nasty error happend!',
                description: JSON.stringify(error)
            });
        }
    };

    initialize();

    return { productData, getProductsFromStore }
});