<script setup lang="ts">
import { Input } from '@/components/ui/input';
import { FormControl, FormField, FormItem, FormLabel, FormMessage } from '@/components/ui/form';
import { Button } from '@/components/ui/button';
import { useForm } from 'vee-validate';
import * as z from 'zod';
import { useToast } from '@/components/ui/toast/use-toast';
import { toTypedSchema } from '@vee-validate/zod';

const { toast } = useToast();

const props = defineProps({
    transitionFunction: Function
});

const newProductSchema = toTypedSchema(z.object({
  email: z.string().email( { message: "Must be a valid email"}),
  password: z.string()
}));

const { isFieldDirty, handleSubmit } = useForm({
  validationSchema: newProductSchema,
});

const onSubmit = handleSubmit(async values => {
    toast({
        title: 'Yay! Product created!',
        description: `Submitted form with ${values}`,
    });
});
</script>

<template>
    <h1 class="text-2xl text-left font-semibold tracking-tight">Sign up</h1>
    <form class="w-1/2" @submit.prevent="onSubmit">
        <!-- Email -->
        <FormField v-slot="{ componentField }" name="email" :validate-on-blur="!isFieldDirty">
            <FormItem class="my-4">
                    <FormLabel class="text-sm">Email</FormLabel>
                    <FormControl>
                        <Input type="text" placeholder="Jensen@myshop.dk" v-bind="componentField" />
                    </FormControl>
                <FormMessage />
            </FormItem>
        </FormField>

        <!-- Password -->
        <FormField v-slot="{ componentField }" name="password" :validate-on-blur="!isFieldDirty">
            <FormItem class="my-4">
                    <FormLabel class="text-sm font-normal">Password</FormLabel>
                    <FormControl>
                        <Input type="password" placeholder="*********" v-bind="componentField" />
                    </FormControl>
                <FormMessage />
            </FormItem>
        </FormField>
        
        <Button variant="secondary" class="w-full mb-2" type="submit" @click="onSubmit">Sign in</Button>
        <Button variant="ghost" class="w-full" @click="props.transitionFunction">Need to sign up?</Button>
    </form>
</template>