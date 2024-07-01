<script setup lang="ts">
import { Button } from '@/components/ui/button';
</script>

<template>
    <div class="w-full h-full flex flex-col justify-center items-center">
      <h3 class="text-2xl font-bold tracking-tight">You have no products</h3>
      <p class="text-sm text-muted-foreground">You can start selling as soon as you add a product.</p>
      <Button class="mt-4">Add Product</Button>
    </div>
</template>