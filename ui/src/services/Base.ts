const BASE_URL = "https://localhost:32001/api/";

export interface ResponseMessage<T> {
    success: boolean,
    message: T
};

const createReturnMessage = <T>(success: boolean, message: T): ResponseMessage<T> => {
    return { success, message }
}

export const GET = <TReturnType>(url: string, jwt?: string) : Promise<ResponseMessage<TReturnType>> => {
    return new Promise(async(resolve, reject) => {
        try {
            const response = await fetch(BASE_URL + url, {
                headers: {
                    "Authorization": `Bearer ${jwt || ''}`,
                },
                method: "GET"
            });

            if(response.ok) {
                resolve(createReturnMessage(true, await response.json()));
            } else {
                reject(createReturnMessage(false, await response.text()));
            }
        } catch(error) {
            if (error instanceof Error) {
                reject(createReturnMessage(false, error.message));
            } else if(typeof error === 'string') {
                reject(createReturnMessage(false, error));
            } else {
                console.error('Unexpected error in GET request:', error);
                reject(createReturnMessage(false, 'An unexpected error occurred'));
            }
        }
    });
};

export const POST = <TDataObject, TReturnType>(url: string, data: TDataObject, jwt?: string) : Promise<ResponseMessage<TReturnType>> => {
    return new Promise(async(resolve, reject) => {
        try {
            const response = await fetch(BASE_URL + url, {
                method: "POST",
                headers: { 
                    "Content-Type": "application/json",
                    "Authorization": `Bearer ${jwt || ''}`,
                },
                body: JSON.stringify(data),
            });

            if(response.ok) {
                resolve(createReturnMessage(true, await response.json()))
            } else {
                reject(createReturnMessage(false, await response.text()));
            }
        } catch (error) {
            if (error instanceof Error) {
                reject(createReturnMessage(false, error.message));
            } else if(typeof error === 'string') {
                reject(createReturnMessage(false, error));
            } else {
                console.error('Unexpected error in POST request:', error);
                reject(createReturnMessage(false, 'An unexpected error occurred'));
            }
        }
    });
}

export const DELETE = <TReturnType>(url: string, jwt?: string) : Promise<ResponseMessage<TReturnType>> => {
    return new Promise(async(resolve, reject) => {
        try {
            const response = await fetch(BASE_URL + url, {
                headers: {
                    "Authorization": `Bearer ${jwt || ''}`,
                },
                method: "DELETE",
            });

            if(response.ok) {
                resolve(createReturnMessage(true, await response.json()))
            } else {
                reject(createReturnMessage(false, await response.text()));
            }
        } catch (error) {
            if (error instanceof Error) {
                reject(createReturnMessage(false, error.message));
            } else if(typeof error === 'string') {
                reject(createReturnMessage(false, error));
            } else {
                console.error('Unexpected error in POST request:', error);
                reject(createReturnMessage(false, 'An unexpected error occurred'));
            }
        }
    });
}