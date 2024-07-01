import { User } from "..";

export type SignInUserDTO = Omit<User, "store" | "id" | "createdAt" | "updatedAt">