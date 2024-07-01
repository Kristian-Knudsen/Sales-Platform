<script setup lang="ts">
import { Bell, Home, Package, Package2, ShoppingCart, Users } from 'lucide-vue-next';
import { Button } from '@/components/ui/button';
import SidebarItem from '@/components/SidebarItem.vue';

</script>

<template>
     <div class="hidden border-r bg-muted/40 md:block">
      <div class="flex h-full max-h-screen flex-col gap-2">
        <div class="flex h-14 items-center border-b px-4 lg:h-[60px] lg:px-6">
          <a href="/" class="flex items-center gap-2 font-semibold">
            <Package2 class="h-6 w-6" />
            <span class="">Customer Store</span>
          </a>
          <Button variant="outline" size="icon" class="ml-auto h-8 w-8">
            <Bell class="h-4 w-4" />
            <span class="sr-only">Toggle notifications</span>
          </Button>
        </div>
        <div class="flex-1">
          <nav class="grid items-start px-2 text-sm font-medium lg:px-4">
            <SidebarItem 
              text="Dashboard"
              :icon="Home"
              link="/"
            />
            <SidebarItem 
            text="Orders"
            :icon="ShoppingCart"
            link="/orders"
            badge="6"
            />
            <SidebarItem 
              text="Products"
              :icon="Package"
              link="/products"
            />
            <SidebarItem 
              text="Customers"
              :icon="Users"
              link="/customers"
            />
            <SidebarItem 
              text="Customer interactions"
              :icon="Users"
              link="/customers"
            />
            <!-- <a href="#" class="flex items-center gap-3 rounded-lg px-3 py-2 text-muted-foreground transition-all hover:text-primary">
              <LineChart class="h-4 w-4" />
              Analytics
            </a> -->
          </nav>
        </div>
      </div>
    </div>
</template>