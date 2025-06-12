# MLAgent-AI

This project simulates an agent learning mechanism using Unity ML-Agents and reinforcement learning. 
The agent is rewarded when it escapes from a wolf and punished when it is caught.

## Project Features

- Unity 2D environment
- ML-Agents PPO training
- Behavior analysis (reward-based)
- Python + Unity integration

## To Run

```bash
pip install -r requirements.txt
mlagents-learn trainer_config.yaml --run-id=Fear01 --env=builds/FearLearn.exe
