import { AddHeroDto } from './AddHeroDto';

export class GetTeamDto {
    id:    number;
    name:  string;
    goals: any[];
    heros: AddHeroDto[];
}