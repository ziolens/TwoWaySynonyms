export interface ITermAndSynonyms {
    term: string
    synonyms: string[]
}

export class ITermAndSynonymsInput {
    term: string
    synonyms: string

    constructor(term: string, synonyms: string) {
        this.term = term
        this.synonyms = synonyms
    }
}