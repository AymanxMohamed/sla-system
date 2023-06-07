export function mapPropertyValueToEnumName<T>(
    enumObj: T,
    propertyValue: any
): keyof T | undefined {
    // @ts-ignore
    const enumEntries = Object.entries(enumObj) as [keyof T, any][];
    const matchingEntry = enumEntries.find(([, value]) => value === propertyValue);
    return matchingEntry ? matchingEntry[0] : undefined;
}



export const formatDate = (date: Date) => {
    const options:any = {
        year: 'numeric',
        month: 'long',
        day: 'numeric',
        hour: 'numeric',
        // minute: 'numeric',
        // second: 'numeric',
        hour12: false,
    };
    return date?.toLocaleString(undefined, options);
}


export function enumToArray(enumObj: any): { id: number; name: string }[] {
    return Object.keys(enumObj)
        .filter((key) => isNaN(Number(key)))
        .map((key) => ({ id: enumObj[key], name: key }));
}