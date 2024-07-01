<script setup lang="ts">
import { Product } from '@/types';
import { Card, CardContent, CardHeader, CardTitle } from '@/components/ui/card';
import { Button } from '@/components/ui/button';
import { FormControl, FormField, FormItem, FormLabel, FormMessage, FormDescription } from '@/components/ui/form';
import * as z from 'zod';
import { toTypedSchema } from '@vee-validate/zod';
import { useForm } from 'vee-validate';
import { Input } from '@/components/ui/input';
import { ref, onMounted, type Ref } from 'vue';
import { Textarea } from '@/components/ui/textarea';
import { Switch } from '@/components/ui/switch';

const props = defineProps<{
    product: Product | null | undefined
}>();

const newData: Ref<Product> = ref({} as Product);

onMounted(() => {
    if(props.product) {
        newData.value = {...props.product};
    }
});


const newProductSchema = toTypedSchema(z.object({
    name: z.string().min(3, { message: "Product name must be more than 3 characters long"}).max(100, { message: "Product name must be no more than 100 characters long"}),
    description: z.string().max(500, { message: "Product description must be no more than 500 characters long"}),
    price: z.number({ message: "Price must be a number! Use , for decimal points"}).positive(),
    isDraft: z.boolean(),
    stock: z.number().optional(),
}));
    
const { isFieldDirty, handleSubmit } = useForm({
    validationSchema: newProductSchema,
});

const onSubmit = handleSubmit(values => {
    console.log('Form submitted!', JSON.stringify(values, null, 2));
});
</script>

<template>
    <!-- Name, description, price/each, stock, isDraft -->

    <div v-if="props.product !== null && props.product !== undefined">
        <Card>
            <CardHeader>
                <CardTitle>Product overview</CardTitle>
            </CardHeader>
            <CardContent>
                <form @submit.prevent="onSubmit">
                    <!-- Name -->
                    <FormField name="name" :validate-on-blur="!isFieldDirty">
                        <FormItem class="my-4">
                                <FormLabel class="text-muted-foreground">Name</FormLabel>
                                <FormControl>
                                    <Input type="text" v-model="newData.name" />
                                </FormControl>
                            <FormMessage />
                        </FormItem>
                    </FormField>

                    <!-- Description -->
                    <FormField name="description" :validate-on-blur="!isFieldDirty">
                        <FormItem class="my-4">
                                <FormLabel class="text-muted-foreground">Description</FormLabel>
                                <FormControl>
                                    <Textarea type="text" v-model="newData.description" />
                                </FormControl>
                            <FormMessage />
                        </FormItem>
                    </FormField>

                    <!-- Price -->
                    <FormField name="price" :validate-on-blur="!isFieldDirty">
                        <FormItem class="my-4">
                                <FormLabel class="text-muted-foreground">Price</FormLabel>
                                <FormControl>
                                    <Input type="number" v-model="newData.price as number" />
                                </FormControl>
                            <FormMessage />
                        </FormItem>
                    </FormField>

                    <!-- Stock -->
                    <FormField name="stock" :validate-on-blur="!isFieldDirty">
                        <FormItem class="mb-4">
                                <FormLabel>Stock</FormLabel>
                                <FormControl>
                                    <Input type="number" v-model="newData.stock as number" />
                                </FormControl>
                            <FormMessage />
                        </FormItem>
                    </FormField>

                    <!-- Is draft -->
                    <FormField name="isDraft">
                        <FormItem class="flex flex-row items-center justify-between rounded-lg border p-4 mb-8">
                            <div class="space-y-0.5">
                                <FormLabel class="text-base">Is product a draft?</FormLabel>
                                <FormDescription>If checked, the product will NOT be displayed to the customers</FormDescription>
                            </div>
                            <FormControl>
                            <Switch
                                :checked="newData.isDraft"
                                @update:checked="() => newData.isDraft = !newData.isDraft"
                            />
                            </FormControl>
                        </FormItem>
                    </FormField>

                    <div class="flex flex-row gap-2">
                        <Button class="w-1/2" type="submit" @click="onSubmit">Save</Button>
                        <Button variant="destructive" class="w-1/2" type="button">Cancel</Button>
                    </div>
                </form>
            </CardContent>
        </Card>
    </div>
    <p v-else>No product found - this should not happen</p>
</template>