<script setup lang="ts">
import { Copy, CreditCard, MoreVertical, Truck } from 'lucide-vue-next';
import { Button } from '@/components/ui/button';
import { Card, CardContent, CardDescription, CardFooter, CardHeader, CardTitle } from '@/components/ui/card';
import { DropdownMenu, DropdownMenuContent, DropdownMenuItem, DropdownMenuSeparator, DropdownMenuTrigger } from '@/components/ui/dropdown-menu';
import { Pagination, PaginationList, PaginationNext, PaginationPrev } from '@/components/ui/pagination';
import { Separator } from '@/components/ui/separator';
import { useOrderStore } from '@/stores';
import { ref, type Ref } from 'vue';
import { getSpecificOrder } from '@/services/Orders';
import { OrderExtended } from '@/types';
import { useToast } from '@/components/ui/toast';

const { toast } = useToast();
const orderStore = useOrderStore();
const orderData: Ref<OrderExtended | undefined> = ref();

orderStore.$subscribe(async (_, state) => {
    const orderId = state.selectedOrder;
    const storeId = localStorage.getItem('store') || '';    

    const response = await getSpecificOrder(storeId, orderId);

    if(response.success) {
        orderData.value = response.message;
    } else {
        toast({
            title: 'Error while fetching the order',
            description: JSON.stringify(response.message),
        });
    }
});
</script>

<template>
    <Card v-if="orderData" class="overflow-hidden">
        <CardHeader class="flex flex-row items-start bg-muted/50">
            <div class="grid gap-0.5">
                <CardTitle class="group flex items-center gap-2 text-lg">Order ID: {{ orderData.id }}
                    <Button size="icon" variant="outline" class="h-6 w-6 opacity-0 transition-opacity group-hover:opacity-100">
                        <Copy class="h-3 w-3" />
                        <span class="sr-only">Copy Order ID</span>
                    </Button>
                </CardTitle>
            <CardDescription>Date: {{ orderData.createdAt }}</CardDescription>
            </div>
            <div class="ml-auto flex items-center gap-1">
            <Button size="sm" variant="outline" class="h-8 gap-1">
                <Truck class="h-3.5 w-3.5" />
                <span class="lg:sr-only xl:not-sr-only xl:whitespace-nowrap">
                Track Order
                </span>
            </Button>
            <DropdownMenu>
                <DropdownMenuTrigger as-child>
                <Button size="icon" variant="outline" class="h-8 w-8">
                    <MoreVertical class="h-3.5 w-3.5" />
                    <span class="sr-only">More</span>
                </Button>
                </DropdownMenuTrigger>
                <DropdownMenuContent align="end">
                <DropdownMenuItem>Edit</DropdownMenuItem>
                <DropdownMenuItem>Export</DropdownMenuItem>
                <DropdownMenuSeparator />
                <DropdownMenuItem>Trash</DropdownMenuItem>
                </DropdownMenuContent>
            </DropdownMenu>
            </div>
        </CardHeader>
        <CardContent class="p-6 text-sm">
            <div class="grid gap-3">
                <div class="font-semibold">
                    Order Details
                </div>
                <ul class="grid gap-3">
                    <li v-for="item in orderData.items" :key="item.name" class="flex items-center justify-between">
                        <span class="text-muted-foreground">
                            {{ item.name }} x <span>{{ item.quantity }}</span>
                        </span>
                        <span>${{ item.price }}</span>
                    </li>
                </ul>
                <Separator class="my-2" />
                <ul class="grid gap-3">
                    <li class="flex items-center justify-between">
                    <span class="text-muted-foreground">Subtotal</span>
                    <span>${{ orderData.totalPrice }}</span>
                    </li>
                    <li class="flex items-center justify-between">
                    <span class="text-muted-foreground">Shipping</span>
                    <span>${{ orderData.shippingFee }}</span>
                    </li>
                    <li class="flex items-center justify-between">
                    <span class="text-muted-foreground">Tax</span>
                    <span>$25.00</span>
                    </li>
                    <li class="flex items-center justify-between font-semibold">
                    <span class="text-muted-foreground">Total</span>
                    <span>${{ orderData.totalPrice + orderData.shippingFee + 25}}</span>
                    </li>
                </ul>
            </div>
            <Separator class="my-4" />
            <div class="grid grid-cols-2 gap-4">
                <div class="grid gap-3">
                    <div class="font-semibold">
                        Shipping Information
                    </div>
                    <address class="grid gap-0.5 not-italic text-muted-foreground">
                    <span>{{ orderData.customerFullName }}</span>
                    <span>{{ orderData.shippingDetails.address }}</span>
                    <span>{{ orderData.shippingDetails.city }}, {{ orderData.shippingDetails.state }}, {{ orderData.shippingDetails.zipCode }} - {{ orderData.shippingDetails.country }}</span>
                    </address>
                </div>
            <div class="grid auto-rows-max gap-3">
                <div class="font-semibold">
                    Billing Information
                </div>
                <div class="text-muted-foreground">
                    Same as shipping address
                </div>
            </div>
            </div>
            <Separator class="my-4" />
            <div class="grid gap-3">
            <div class="font-semibold">
                Customer Information
            </div>
            <dl class="grid gap-3">
                <div class="flex items-center justify-between">
                <dt class="text-muted-foreground">
                    Customer
                </dt>
                <dd>{{ orderData.customerFullName }}</dd>
                </div>
                <div class="flex items-center justify-between">
                <dt class="text-muted-foreground">
                    Email
                </dt>
                <dd>
                    <a href="mailto:">{{ orderData.customerEmail }}</a>
                </dd>
                </div>
                <div class="flex items-center justify-between">
                <dt class="text-muted-foreground">
                    Phone
                </dt>
                <dd>
                    <a href="tel:">{{ orderData.customerPhoneNumber }}</a>
                </dd>
                </div>
            </dl>
            </div>
            <Separator class="my-4" />
            <div class="grid gap-3">
            <div class="font-semibold">
                Payment Information
            </div>
            <dl class="grid gap-3">
                <div class="flex items-center justify-between">
                <dt class="flex items-center gap-1 text-muted-foreground">
                    <CreditCard class="h-4 w-4" />
                    Visa
                </dt>
                <dd>{{ orderData.paymentInformation }}</dd>
                </div>
            </dl>
            </div>
        </CardContent>
        <CardFooter class="flex flex-row items-center border-t bg-muted/50 px-6 py-3">
            <div class="text-xs text-muted-foreground">
            Updated <time dateTime="2023-11-23">November 23, 2023</time>
            </div>
            <Pagination class="ml-auto mr-0 w-auto">
            <PaginationList class="gap-1">
                <PaginationPrev variant="outline" class="h-6 w-6" />
                <PaginationNext variant="outline" class="h-6 w-6" />
            </PaginationList>
            </Pagination>
        </CardFooter>
    </Card>
</template>