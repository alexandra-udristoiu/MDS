export interface Hw {
    id: number;
    title: string;
    text: string;
    createdDate: string;
    dueDate: string;
    userId: string;
    userName: string;
    file: File;
    resolveFile: File;
    resolved: boolean;
}