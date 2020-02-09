export interface Stats {
    date: Date,
    lines: StatLine[]
}

export interface StatLine {
    nbOccurence: number,
    name: string,
    // we use the type has a reference
    type: number,
    isErrorCode: boolean
}