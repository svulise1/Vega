export interface KeyValuePair 
{
    id: number;
    name: string;
}

export interface Contact {
    contactName: string;
    contactPhone: string;
    contactEmail: string;
}

export interface Vechile {

    id: number;
    model: KeyValuePair;
    make: KeyValuePair;
    isRegistered: boolean;
    features: KeyValuePair[];
    contact: Contact;
    lastUpdate: string;
}

export interface SaveVechile {

    id: number;
    modelId: number;
    makeId: number;
    isRegistered: boolean;
    features: number[];
    contact: Contact;
}