import * as momentTimezone from 'moment-timezone';

export default (): Date => {
    return new Date(momentTimezone.tz('America/Sao_Paulo')
        .format('YYYY-MM-DD HH:mm:ss.SSS'));
}