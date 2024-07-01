<script setup lang="ts">
import Layout from '@/components/Layout.vue';
import NoProducts from '@/features/products/NoProducts.vue';
import ProductsOverview from '@/features/products/ProductsOverview.vue';
import { useProductStore } from '@/stores';
const productStore = useProductStore();

</script>

<template>
  <Layout>
    <div class="flex flex-col gap-4">
      <h1 class="text-lg font-semibold md:text-2xl">Inventory</h1>
      <ProductsOverview v-if="productStore.productData.length > 0" />
      <NoProducts v-else />

    </div>
  </Layout>
</template>