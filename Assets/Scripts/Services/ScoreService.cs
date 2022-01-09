using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ScoreService
{
    int score = 0;

    public int Score => score;

	public ScoreService(int startScore = 0)
	{
		score = startScore;
	}

	public void AddScore(int score)
	{
		this.score += score;
	}
}


