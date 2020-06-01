export interface Tag {
    id: number;
    name: string;
    isDeleted: boolean;
}
export interface GetTagForUpdateOutput {
    tag: Tag
}