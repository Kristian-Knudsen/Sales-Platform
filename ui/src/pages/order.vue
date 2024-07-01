<script setup lang="ts">
import Layout from '@/components/Layout.vue';
import OrderTable from '@/features/order/Table.vue';
import SelectedOrder from '@/features/order/SelectedOrder.vue';
// import { ref, onMounted } from 'vue';

// const selectedOrder = ref("");
</script>

<template>
<Layout>
  <div class="flex flex-col lg:flex-row h-full gap-4">
    <OrderTable />
    <SelectedOrder />
  </div>
</Layout>

</template>