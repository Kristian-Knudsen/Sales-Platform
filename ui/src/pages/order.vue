<script setup lang="ts">
import Layout from '@/components/Layout.vue';
import OrderTable from '@/features/order/Table.vue';
import SelectedOrder from '@/features/order/SelectedOrder.vue';
</script>

<template>
<Layout class="h-full max-h-full">
  <div class="flex flex-col lg:flex-row max-h-full h-full gap-4">
    <OrderTable />
    <SelectedOrder />
  </div>
</Layout>

</template>