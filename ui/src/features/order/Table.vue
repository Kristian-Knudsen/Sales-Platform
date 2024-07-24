<script setup lang="ts">
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from '@/components/ui/table';
import { Card, CardHeader, CardTitle, CardDescription, CardContent } from '@/components/ui/card';
import { useOrderStore } from '@/stores';
import { OrderStatusText } from '@/types';
import { makeDateNice } from '@/utils';
const orderStore = useOrderStore();

const setSelectedOrder = (id: string) => {
  orderStore.selectedOrder = id;
}
</script>

<template>
  <Card class="h-full flex-grow">
    <CardHeader class="px-7">
      <CardTitle>Orders</CardTitle>
      <CardDescription>
        Recent orders from your store.
      </CardDescription>
    </CardHeader>

    <CardContent>
      <Table>
        <TableHeader>
          <TableRow>
            <TableHead class="text-center">Customer</TableHead>
            <!-- <TableHead class="hidden sm:table-cell">
              Type
            </TableHead> -->
            <TableHead class="hidden sm:table-cell text-center">
              Status
            </TableHead>
            <TableHead class="hidden md:table-cell text-center">
              Date
            </TableHead>
            <TableHead class="text-center">
              Amount ($)
            </TableHead>
          </TableRow>
        </TableHeader>
        <TableBody>
          <TableRow v-for="order in orderStore.simpleOrderData" class="bg-accent text-center" @click="setSelectedOrder(order.id)">
            <TableCell>
              <div class="font-medium">
                {{ order.fullName }}
              </div>
              <div class="hidden text-sm text-muted-foreground md:inline">
                {{ order.email }}
              </div>
            </TableCell>
            <TableCell class="hidden sm:table-cell">
              {{ OrderStatusText[order.status] }}
            </TableCell>
            <!-- <TableCell class="hidden sm:table-cell">
              <Badge class="text-xs" variant="secondary">
                Fulfilled
              </Badge>
            </TableCell> -->
            <TableCell class="hidden md:table-cell">
              {{ makeDateNice(order.createdAt) }}
            </TableCell>
            <TableCell>
              {{ order.totalPrice }}
            </TableCell>
          </TableRow>
        </TableBody>
      </Table>
    </CardContent>
  </Card>
</template>