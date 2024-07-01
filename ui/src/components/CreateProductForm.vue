<script setup lang="ts">
import { Input } from '@/components/ui/input';
import { Switch } from '@/components/ui/switch';
import { FormControl, FormDescription, FormField, FormItem, FormLabel, FormMessage } from '@/components/ui/form';
import { Textarea } from '@/components/ui/textarea';
import { Button } from '@/components/ui/button';
import { toTypedSchema } from '@vee-validate/zod';
import { useForm } from 'vee-validate';
import { createProduct } from '@/services/Products';
import { CreateProductDTO } from '@/types/dto/Product';
import * as z from 'zod';
import { useToast } from '@/components/ui/toast/use-toast';


const { toast } = useToast()
const newProductSchema = toTypedSchema(z.object({
  name: z.string().min(3, { message: "Product name must be more than 3 characters long"}).max(100, { message: "Product name must be no more than 100 characters long"}),
  description: z.string().max(500, { message: "Product description must be no more than 500 characters long"}),
  price: z.number({ message: "Price must be a number! Use , for decimal points"}).positive(),
  isDraft: z.boolean().default(false),
  stock: z.number().optional().default(0)
}));

const { isFieldDirty, handleSubmit } = useForm({
  validationSchema: newProductSchema,
});

const onSubmit = handleSubmit(async values => {
    if(localStorage.getItem('store') === null) {
        console.error("localStorage store not set in CreateProductForm.vue");
    }

    const data: CreateProductDTO = {
        ...values,
        storeId: localStorage.getItem('store')
    };

    try {
        const response = await createProduct(data);
        if(props.closeFunction) {
            props.closeFunction();
        }
        toast({
            title: 'Yay! Product created!',
            description: `A product was created and was given the id: ${response.message}`,
        });
    } catch (error) {
        toast({
            title: 'Nay :( - An error occured',
            description: JSON.stringify(error),
            variant: "destructive"
        });
    }

});

const props = defineProps({
    closeFunction: Function
});
</script>

<template>
    <form @submit.prevent="onSubmit">
        <!-- Name -->
        <FormField v-slot="{ componentField }" name="name" :validate-on-blur="!isFieldDirty">
            <FormItem class="my-4">
                    <FormLabel>Name*</FormLabel>
                    <FormControl>
                        <Input type="text" placeholder="Fisherman's Hat" v-bind="componentField" />
                    </FormControl>
                <FormMessage />
            </FormItem>
        </FormField>

        <!-- Description -->
        <FormField v-slot="{ componentField }" name="description" :validate-on-blur="!isFieldDirty">
            <FormItem class="mb-4">
                    <FormLabel>Description*</FormLabel>
                    <FormControl>
                        <Textarea maxlength="500" type="text" placeholder="A very nice hat that can be used by fishers" v-bind="componentField" />
                        <p>Characters: {{ componentField?.modelValue?.length | 0 }}/500</p>
                    </FormControl>
                <FormMessage />
            </FormItem>
        </FormField>

        <div class="flex flex-row gap-4 w-full">
            <!-- Price -->
            <FormField v-slot="{ componentField }" name="price" :validate-on-blur="!isFieldDirty">
                <FormItem class="mb-4 w-1/2">
                        <FormLabel>Price/each*</FormLabel>
                        <FormControl>
                            <Input type="number" placeholder="19.99" v-bind="componentField" />
                        </FormControl>
                    <FormMessage />
                </FormItem>
            </FormField>
            
            <!-- Stock -->
            <FormField v-slot="{ componentField }" name="stock" :validate-on-blur="!isFieldDirty">
                <FormItem class="mb-4 w-1/2">
                        <FormLabel>Stock</FormLabel>
                        <FormControl>
                            <Input type="number" placeholder="12" v-bind="componentField" />
                        </FormControl>
                    <FormMessage />
                </FormItem>
            </FormField>
        </div>

        <!-- Is draft -->
        <FormField v-slot="{ value, handleChange }" name="isDraft">
            <FormItem class="flex flex-row items-center justify-between rounded-lg border p-4 mb-8">
                <div class="space-y-0.5">
                    <FormLabel class="text-base">Is product a draft?</FormLabel>
                    <FormDescription>If checked, the product will NOT be displayed to the customers</FormDescription>
                </div>
                <FormControl>
                <Switch
                    :checked="value"
                    @update:checked="handleChange"
                />
                </FormControl>
            </FormItem>
        </FormField>


        <div class="flex flex-row gap-2">
            <Button class="w-1/2" type="submit" @click="onSubmit">Create</Button>
            <Button class="w-1/2 border-red-500 text-red-500 hover:bg-red-500 hover:text-white" variant="outline" type="button" @click="props.closeFunction">Cancel</Button>
        </div>
    </form>
</template>