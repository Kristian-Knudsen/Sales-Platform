<script setup lang="ts">
import { MoreHorizontal } from 'lucide-vue-next';
import { Badge } from '@/components/ui/badge';
import { Button } from '@/components/ui/button';
import { Card, CardContent, CardDescription, CardFooter, CardHeader, CardTitle } from '@/components/ui/card';
import { DropdownMenu, DropdownMenuContent, DropdownMenuItem, DropdownMenuLabel, DropdownMenuTrigger } from '@/components/ui/dropdown-menu';
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from '@/components/ui/table';
import { PlusCircle } from 'lucide-vue-next';
import CreateProductModal from './CreateProductModal.vue';
import DeleteProductModal from './DeleteProductModal.vue';
import { ref, computed, type Ref } from 'vue'; 
import { useProductStore } from '@/stores';

const productStore = useProductStore();

const numberProductsFitsPage = () => {
    const viewportHeight = window.innerHeight;
    if(viewportHeight <= 0) return;

    return Math.floor(viewportHeight / 115);
};

const createProductShouldOpen = ref(false);
const productDeletionShouldOpen: Ref<null | string> = ref(null);

const paginationCurrentPage = ref(1);
const paginationPageSize = numberProductsFitsPage() || 10;
const displayedProducts = computed(() => {
    const startIndex = (paginationCurrentPage.value - 1) * paginationPageSize;
    const endIndex = Math.min(startIndex + paginationPageSize, productStore.productData.length);
    return { "products": productStore.productData.slice(startIndex, endIndex), "start": startIndex, "end": endIndex };
});

const formatCreatedAtDates = (toFormat: any) => toFormat.slice(0,10);

const createModalCloseFunction = () => {
    createProductShouldOpen.value = false;
    productStore.getProductsFromStore();
}

const deleteModalCloseFunction = () => {
    productDeletionShouldOpen.value = null;
    productStore.getProductsFromStore();
}

</script>

<template>
    <CreateProductModal :should-open="createProductShouldOpen" :close-function="createModalCloseFunction" />
    <DeleteProductModal :product="productStore.productData.find(p => p.id === productDeletionShouldOpen)" :should-open="productDeletionShouldOpen !== null" :close-function="deleteModalCloseFunction" />
    <Card>
        <CardHeader class="flex flex-row">
            <div>
                <CardTitle>Products</CardTitle>
                <CardDescription>
                    Manage your products and view their sales performance.
                </CardDescription>
            </div>
            <div class="ml-auto flex items-center gap-2">
              <!-- <Button size="sm" variant="outline" class="h-7 gap-1">
                <File class="h-3.5 w-3.5" />
                <span class="sr-only sm:not-sr-only sm:whitespace-nowrap">
                  Export
                </span>
              </Button> -->
              <Button size="sm" class="h-7 gap-1" @click="createProductShouldOpen = true">
                <PlusCircle class="h-3.5 w-3.5" />
                <span class="sr-only sm:not-sr-only sm:whitespace-nowrap">
                  Add Product
                </span>
              </Button>
            </div>
        </CardHeader>
        <CardContent>
            <Table>
                <TableHeader>
                    <TableRow>
                        <TableHead class="hidden w-[100px] sm:table-cell">
                            <span class="sr-only">img</span>
                        </TableHead>
                        <TableHead>Name</TableHead>
                        <TableHead>Status</TableHead>
                        <TableHead class="hidden md:table-cell">
                            Price
                        </TableHead>
                        <TableHead class="hidden md:table-cell">
                            Total Stock
                        </TableHead>
                        <TableHead class="hidden md:table-cell">
                            Created at
                        </TableHead>
                        <TableHead>
                            <span class="sr-only">Actions</span>
                        </TableHead>
                    </TableRow>
                </TableHeader>
                <TableBody>
                    <TableRow v-for="product in displayedProducts.products">
                        <TableCell class="hidden sm:table-cell">
                            <img alt="Product image" class="aspect-square rounded-md object-cover" height="64"
                                src="https://placehold.co/64" width="64">
                        </TableCell>
                        <TableCell class="font-medium">
                            {{ product.name }}
                        </TableCell>
                        <TableCell>
                            <Badge :variant="product.isDraft === true ? 'destructive' : 'default'">
                                {{ product.isDraft === true ? 'Draft' : 'Active' }}
                            </Badge>
                        </TableCell>
                        <TableCell class="hidden md:table-cell">
                            ${{ product.price }}
                        </TableCell>
                        <TableCell class="hidden md:table-cell">
                            {{ product.stock }}
                        </TableCell>
                        <TableCell class="hidden md:table-cell">
                            {{ formatCreatedAtDates(product.createdAt) }}
                        </TableCell>
                        <TableCell>
                            <DropdownMenu>
                                <DropdownMenuTrigger as-child>
                                    <Button aria-haspopup="true" size="icon" variant="ghost">
                                        <MoreHorizontal class="h-4 w-4" />
                                        <span class="sr-only">Toggle menu</span>
                                    </Button>
                                </DropdownMenuTrigger>
                                <DropdownMenuContent align="end">
                                    <DropdownMenuLabel>Actions</DropdownMenuLabel>
                                    <DropdownMenuItem>Edit</DropdownMenuItem>
                                    <DropdownMenuItem @click="() => productDeletionShouldOpen = product.id">Delete</DropdownMenuItem>
                                </DropdownMenuContent>
                            </DropdownMenu>
                        </TableCell>
                    </TableRow>
                </TableBody>
            </Table>
        </CardContent>
        <CardFooter>
            <div class="flex flex-row justify-between w-full">
                <div class="text-xs text-muted-foreground">Showing <strong>{{ displayedProducts.start }} - {{ displayedProducts.end }}</strong> of <strong>{{ productStore.productData.length }}</strong> products</div>

                <div class="flex gap-2">
                    <Button size="sm" class="h-7" disabled v-if="paginationCurrentPage === 1">Previous page</Button>
                    <Button size="sm" class="h-7" @click="paginationCurrentPage--" v-else>Previous page</Button>

                    <Button size="sm" class="h-7" disabled v-if="displayedProducts.end === productStore.productData.length">Next page</Button>
                    <Button size="sm" class="h-7" @click="paginationCurrentPage++" v-else>Next page</Button>
                </div>
            </div>
        </CardFooter>
    </Card>
</template>