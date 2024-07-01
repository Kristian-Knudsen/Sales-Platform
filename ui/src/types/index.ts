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