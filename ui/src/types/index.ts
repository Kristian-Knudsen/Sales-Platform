export interface BaseModel {
    id: string,
    createdAt: Date
    updatedAt?: Date | null;
};

export interface Product extends BaseModel {
    [id: string]: unknown
    name: string,
    description: string,
    price: Number,
    isDraft: boolean,
    stock: Number,
};

export interface User extends BaseModel {
    email?: string,
    password?: string,
    store: Store
};

export interface Store extends BaseModel {
   name: string,
   userId: string,
   user: User,
   products? : Product[] | null,
};

export interface RouteMeta {
    public?: boolean,
};

export enum OrderStatus {
    AwaitingStatus,
    Pending,
    AwaitingPayment,
    AwaitingPickAndPack,
    AwaitingShipment,
    AwaitingPickup,
    Shipped,
    Cancelled,
    Refunded,
    ManualVerificationNeeded
}

export interface Customer {
    firstName: string,
    lastName: string,
    email: string,
    shippingDetailsId?: string | null,
    orders?: Order[] | null;
}

export interface OrderItem {
    quantity: number,
    productId: string,
    orderId: string,
    product: Product,
    order: Order
}

export interface OrderSimple {
    id: string,
    createdAt: Date,
    fullName: string,
    status: OrderStatus,
    email: string,
    totalPrice: number
}

export interface OrderItemSimple {
    name: string,
    quantity: number,
    price: number,
}

export interface ShippingDetailsSimple {
    address: string,
    city: string,
    state: string,
    country: string,
    zipCode: string
}

export interface OrderExtended {
    id: string,
    createdAt: Date,
    items: OrderItemSimple[],
    totalPrice: number,
    shippingFee: number,
    shippingDetails: ShippingDetailsSimple,
    customerFullName: string,
    customerEmail: string,
    customerPhoneNumber:string,
    paymentInformation: string
}

export interface Order extends BaseModel {
    totalPrice: number,
    status: OrderStatus,
    customerId: string,
    storeId: string,
    customer: Customer,
    store: Store,
    orderItems: OrderItem
}