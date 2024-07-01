<script setup lang="ts">
import warehouseImg from '@/assets/warehouse.png';
import SignInForm from '@/components/SignInForm.vue';
</script>

<template>
    <div class="flex flex-row h-full bg-[#2c2c2c]">
            <div class="w-1/2 h-full text-white flex flex-col items-center justify-center">
                <SignInForm />
            </div>
        <div class=" w-1/2 h-full flex flex-col items-center justify-center">
            <img :src="warehouseImg" class="w-96" />
        </div>
    </div>
</template>