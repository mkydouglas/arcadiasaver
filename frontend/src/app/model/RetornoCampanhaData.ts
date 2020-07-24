import { Player } from './Player';

export class RetornoCampanhaData {
    id:              number;
    campaignId:      string;
    name:            string;
    numberOfPlayers: number;
    players:         Player[];
}