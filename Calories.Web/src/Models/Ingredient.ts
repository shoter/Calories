export interface Ingredient {
    id : Number;
    name: string;
    calories: Number;
    sizeTypeID: Number;
    proteins?: Number;
    fat?: Number;
    carbonhydrates?: Number;
    roughage?: Number;
    magnes?: Number;
    potas?: Number;
    calcium?: Number;
    phosphor? : Number;
    iron?: Number;
    zinc?: Number;
    copper?: Number;
    mangan?: Number;
    sodium?: Number;
    jod?: Number;

    [key: string]: Number | string | undefined;
}