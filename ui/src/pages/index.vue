<script setup lang="ts">
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from '@/components/ui/table';
import { Sheet, SheetContent, SheetHeader, SheetTitle, SheetDescription } from '@/components/ui/sheet';
import { Button } from '@/components/ui/button';
import { ToggleGroup, ToggleGroupItem } from '@/components/ui/toggle-group';
import { getStoreProducts } from '@/services/Stores';
import CreateProductForm from '@/components/CreateProductForm.vue';
import { ref, onMounted, type Ref, watch } from 'vue';
import { Product } from '@/types';
import ViewProductPage from '@/components/ViewProductPage.vue';
import Layout from '@/components/Layout.vue';

const productData: Ref<Product[]> = ref([]);
const displayedProducts: Ref<Product[]> = ref([]);
const selectedSort: Ref<string> = ref("all");
const displayIsAddingNewProduct: Ref<boolean> = ref(false);
const shouldDisplayViewProductSheet: Ref<boolean> = ref(false);
const currentlyDisplayedViewProduct: Ref<string> = ref("");

onMounted(async () => {
    await getStoreProducts()
        .then(d => productData.value = d)
        .catch(e => console.log(e));
    
    displayedProducts.value = productData.value;
});

watch(selectedSort, () => {
    if(selectedSort.value === 'draft') {
        displayedProducts.value = productData.value.filter(p => p.isDraft === true);
    } else if(selectedSort.value === 'active') {
        displayedProducts.value = productData.value.filter(p => p.isDraft === false);
    } else {
        displayedProducts.value = productData.value;
    }
});
</script>

<template>
    <Layout>
        <div class="p-4">
        <h1 class="text-xl">Hello Kristian - welcome to the store Snuts Kiosk</h1>
        <div class="flex flex-row w-full justify-between">
            <h2 class="text-lg text-muted-foreground">Products</h2>
            <Button @click="displayIsAddingNewProduct = true">Add new product</Button>
        </div>
        
        <div class="flex flex-row">
            <ToggleGroup type="single">
                <ToggleGroupItem value="a" @click="selectedSort = 'all'">
                    All
                </ToggleGroupItem>
                <ToggleGroupItem value="b" @click="selectedSort = 'active'">
                    Active
                </ToggleGroupItem>
                <ToggleGroupItem value="c" @click="selectedSort = 'draft'">
                    Drafts
                </ToggleGroupItem>
            </ToggleGroup>
        </div>

        <Table v-if="productData.length > 0" class="w-fit">
            <TableHeader>
                <TableRow>
                    <TableHead class="px-4">Id</TableHead>
                    <TableHead class="px-4">Name</TableHead>
                    <TableHead class="px-4">Description</TableHead>
                    <TableHead class="px-4">Price</TableHead>
                    <TableHead class="px-4">Stock</TableHead>
                    <TableHead class="px-4">Is draft?</TableHead>
                </TableRow>
            </TableHeader>
            <TableBody>
                <TableRow @click="() => {
                    currentlyDisplayedViewProduct = product.id;
                    shouldDisplayViewProductSheet = true;
                }" class="text-center" v-for="product in displayedProducts">
                    <TableCell class="font-medium">{{ product.id }}</TableCell>
                    <TableCell>{{ product.name }}</TableCell>
                    <TableCell>{{ product.description }}</TableCell>
                    <TableCell>$ {{ product.price }}</TableCell>
                    <TableCell>{{ product.stock }}</TableCell>
                    <TableCell>{{ product.isDraft === true ? '👍' : '❌' }}</TableCell>
                </TableRow>
            </TableBody>
        </Table>
        <p v-else>No products found</p>

        <Sheet :open="shouldDisplayViewProductSheet" :onUpdate:open="e => shouldDisplayViewProductSheet = e">
            <SheetContent class="w-[400px] sm:w-[540px]">
                <SheetHeader>
                    <SheetTitle>Viewing product</SheetTitle>
                </SheetHeader>
                <SheetDescription>
                    <ViewProductPage :closeFunction="() => shouldDisplayViewProductSheet = false" :product="displayedProducts.find(p => p.id === currentlyDisplayedViewProduct)" />
                </SheetDescription>
            </SheetContent>
        </Sheet>

        <Sheet :open="displayIsAddingNewProduct" :onUpdate:open="e => displayIsAddingNewProduct = e">
            <SheetContent class="max-w-[500px] sm:max-w-[680px]">
                <SheetHeader>
                    <SheetTitle>New product</SheetTitle>
                </SheetHeader>
                <SheetDescription>
                    <CreateProductForm :closeFunction="() => displayIsAddingNewProduct = false" />
                </SheetDescription>
            </SheetContent>
        </Sheet>
    </div>
    </Layout>
</template>