import { SignInUserDTO } from "@/types/dto/User";
import { POST, ResponseMessage } from "./Base";

export interface signInResponse {
    id: string,
    storeId: string | null,
    jwt: string
};

export const signInUser = async (data: SignInUserDTO) : Promise<ResponseMessage<signInResponse>> => {
    try {
        return await POST<SignInUserDTO, signInResponse>("users/signin", data);
    } catch (error) {
        return error as ResponseMessage<signInResponse>;
    }
}