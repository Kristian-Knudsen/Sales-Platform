<script setup lang="ts">
import { Sheet, SheetContent, SheetHeader, SheetTitle, SheetDescription} from '@/components/ui/sheet';
import { Product } from '@/types';
import { Button } from '@/components/ui/button';
import { deleteProduct } from '@/services/Products';
import { useToast } from '@/components/ui/toast';

const props = defineProps<{
    product: Product | undefined,
    shouldOpen: boolean,
    closeFunction: () => any
}>();
const { toast } = useToast();

const onSubmit = async () => {
    try {
        if(props.product) {
            const response = await deleteProduct(props.product.id);
            if(props.closeFunction) {
                props.closeFunction();
            }
            toast({
                title: 'Yay! Product deleted!',
                description: `The product with id: ${response.message} was deleted`,
            });
        }
    } catch (error) {
        toast({
            title: 'Nay :( - An error occured',
            description: JSON.stringify(error),
            variant: "destructive"
        });
    }
};
</script>

<template>
    <Sheet v-if="props.product" :open="props.shouldOpen" :onUpdate:open="closeFunction">
        <SheetContent class="max-w-[500px] sm:max-w-[680px]">
            <SheetHeader>
                <SheetTitle>Are you sure you want to delete this product?</SheetTitle>
            </SheetHeader>
            <SheetDescription>
                <p>Id: {{ props.product.id }}</p>
                <p>Name: {{ props.product.name }}</p>
                <p>Description: {{ props.product.description }}</p>
                <p>Price: {{ props.product.price }}</p>
                <p>Stock: {{ props.product.stock }}</p>

                <div class="flex flex-row gap-2 mt-4">
                    <Button class="w-1/2 border-red-500 text-red-500 hover:bg-red-500 hover:text-white" variant="outline" type="button" @click="onSubmit">Delete</Button>
                    <Button class="w-1/2" type="submit" @click="props.closeFunction">Cancel</Button>
                </div>
            </SheetDescription>
        </SheetContent>
    </Sheet>
</template>